import { Metadata } from "next";
import { getProductBySlug } from "@/services/productService";
import ProductDetailClient from "./ProductDetailClient";
import { notFound } from "next/navigation";

interface Props {
  params: Promise<{
    slug: string;
    locale: string;
  }>;
}

export async function generateMetadata({ params }: Props): Promise<Metadata> {
  const { slug } = await params; 
  
  try {
    const product = await getProductBySlug(slug);
    if (!product) return { title: "Ürün Bulunamadı" };

    return {
      title: `${product.name} | ProductFlow`,
      description: product.description,
    };
  } catch (error) {
    return { title: "Hata | ProductFlow" };
  }
}

export default async function ProductPage({ params }: Props) {
  const { slug } = await params; 

  try {
    const product = await getProductBySlug(slug);

    if (!product) {
      notFound();
    }

    return <ProductDetailClient product={product} />;
  } catch (error) {
    console.error("API Hatası:", error);
    return <div className="text-center py-20">Hata Detayı: {String(error)}</div>;
  }
}