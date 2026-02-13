"use client";
import Image from "next/image";
import Link from "next/link";
import { Product } from "@/types/product";
import { useDispatch } from "react-redux";
import { addToBasket } from "@/stores/features/basketSlice";

export default function ProductCard({ product, locale }: { product: Product, locale: string }) {
  const dispatch = useDispatch();

  return (
    <div className="relative group border rounded-xl overflow-hidden hover:shadow-2xl transition duration-300 bg-white">
      <Link href={`/product/${product.slug}`}>
        <div className="relative h-56 w-full">
          <Image 
            src={product.imageUrl?.startsWith("http") ? product.imageUrl : "https://via.placeholder.com/300"} 
            alt={product.name} 
            fill 
            className="object-cover group-hover:scale-110 transition-transform"
          />
        </div>
        <div className="p-4">
          <span className="text-[10px] bg-blue-100 text-blue-700 px-2 py-1 rounded-full uppercase font-bold">
            {product.categoryName}
          </span>
          <h3 className="font-bold text-gray-800 mt-2 truncate">{product.name}</h3>
          <p className="text-lg font-extrabold text-blue-600 mt-2">{product.price.toLocaleString('tr-TR')} TL</p>
        </div>
      </Link>
      <div className="absolute bottom-4 right-4">
        <button 
          onClick={() => dispatch(addToBasket(product))}
          className="p-3 bg-gray-900 text-white rounded-full hover:bg-blue-600 transition shadow-lg"
        >
          <svg xmlns="http://www.w3.org/2000/svg" className="h-5 w-5" fill="none" viewBox="0 0 24 24" stroke="currentColor">
            <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M12 6v6m0 0v6m0-6h6m-6 0H6" />
          </svg>
        </button>
      </div>
    </div>
  );
}