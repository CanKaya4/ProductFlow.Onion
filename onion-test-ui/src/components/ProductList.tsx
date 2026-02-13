"use client";
import { Product } from "@/types/product";
import ProductCard from "./ProductCard";

interface ProductListProps {
  products: Product[];
  loading: boolean;
  locale: string;
}

export default function ProductList({ products, loading, locale }: ProductListProps) {
  if (loading) {
    return (
      <div className="flex justify-center items-center h-64 text-blue-600 font-bold">
        Yükleniyor...
      </div>
    );
  }

  if (products.length === 0) {
    return (
      <div className="text-center py-20 bg-gray-50 rounded-xl border-2 border-dashed">
        <p className="text-gray-500">Aradığınız kriterlere uygun ürün bulunamadı.</p>
      </div>
    );
  }

  return (
    <div className="grid grid-cols-1 sm:grid-cols-2 lg:grid-cols-3 gap-6">
      {products.map((product) => (
        <ProductCard key={product.id} product={product} locale={locale} />
      ))}
    </div>
  );
}