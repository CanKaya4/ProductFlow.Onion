"use client";
import { useEffect, useState } from "react";
import { getProducts } from "@/services/productService";
import { getCategories } from "@/services/categoryService"; 
import { Product } from "@/types/product";
import Image from "next/image";
import Link from "next/link";
import { addToBasket } from "@/stores/features/basketSlice";
import { useDispatch } from "react-redux";
import {useTranslations,useLocale} from 'next-intl';
import ProductFilter from "@/components/ProductFilter";
import ProductList from "@/components/ProductList";

export default function HomePage() {
  const dispatch = useDispatch();
  const [products, setProducts] = useState<Product[]>([]);
  const [categories, setCategories] = useState<any[]>([]); 
  const [sortOrder, setSortOrder] = useState<"asc" | "desc" | "">(""); 
  const [loading, setLoading] = useState(true);
  const t = useTranslations('Filter');
  const locale = useLocale();
  
  // Filtre State'leri
  const [minPrice, setMinPrice] = useState<number | "">("");
  const [maxPrice, setMaxPrice] = useState<number | "">("");
  const [categoryId, setCategoryId] = useState("");

  const fetchData = async () => {
    setLoading(true);
    try {
      const [productData, categoryData] = await Promise.all([
        getProducts({
          minPrice: minPrice || undefined,
          maxPrice: maxPrice || undefined,
          categoryId: categoryId || undefined
        }),
        getCategories()
      ]);
      
      setProducts(productData);
      setCategories(categoryData);
    } catch (error) {
      console.error("Veri çekme hatası:", error);
    } finally {
      setLoading(false);
    }
  };

  useEffect(() => {
    fetchData();
  }, []);
const sortedProducts = [...products].sort((a, b) => {
  if (sortOrder === "asc") return a.price - b.price; 
  if (sortOrder === "desc") return b.price - a.price; 
  return 0;
});
  return (
     <div className="max-w-7xl mx-auto px-4 py-12 flex flex-col md:flex-row gap-8">
      <ProductFilter 
        categories={categories}
        categoryId={categoryId}
        setCategoryId={setCategoryId}
        minPrice={minPrice}
        setMinPrice={setMinPrice}
        maxPrice={maxPrice}
        setMaxPrice={setMaxPrice}
        sortOrder={sortOrder}
        setSortOrder={setSortOrder}
        onFetch={fetchData}
      />

      <main className="flex-1">
        <ProductList 
          products={sortedProducts} 
          loading={loading} 
          locale={locale} 
        />
      </main>
    </div>
  );
}