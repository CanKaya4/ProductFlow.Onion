"use client";

import Image from "next/image";
import { Product } from "@/types/product";
import { useDispatch } from "react-redux";
import { addToBasket } from "@/stores/features/basketSlice";

interface Props {
  product: Product;
}

export default function ProductDetailClient({ product }: Props) {
  const dispatch = useDispatch();

  const handleAddToBasket = () => {
    dispatch(addToBasket(product));

  };

  return (
    <div className="max-w-7xl mx-auto px-4 py-12">
      <div className="flex flex-col md:flex-row gap-12">
        <div className="w-full md:w-1/2 relative aspect-square rounded-2xl overflow-hidden bg-gray-50 border">
          <Image
            src={product.imageUrl?.startsWith("http") ? product.imageUrl : "https://images.pexels.com/photos/1036856/pexels-photo-1036856.jpeg"}
            alt={product.name}
            fill
            className="object-cover"
            priority 
            sizes="(max-width: 768px) 100vw, 50vw"
          />
        </div>

        <div className="w-full md:w-1/2 space-y-6">
          <div className="space-y-2">
            <span className="text-blue-600 font-bold uppercase tracking-wider text-sm">
              {product.categoryName}
            </span>
            <h1 className="text-4xl font-extrabold text-gray-900">{product.name}</h1>
          </div>

          <p className="text-3xl font-bold text-gray-900">
            {product.price.toLocaleString('tr-TR')} TL
          </p>

          <div className="border-t border-b py-6">
            <h3 className="text-lg font-bold mb-2">Ürün Açıklaması</h3>
            <p className="text-gray-600 leading-relaxed">{product.description}</p>
          </div>

          <div className="flex items-center gap-4">
            <div className="text-sm">
              <span className="text-gray-500">Stok Durumu:</span>
              <span className={`ml-2 font-bold ${product.stock > 0 ? 'text-green-600' : 'text-red-600'}`}>
                {product.stock > 0 ? `${product.stock} Adet` : 'Tükendi'}
              </span>
            </div>
          </div>

          <div className="flex gap-4">
            <button 
              onClick={handleAddToBasket}
              className="flex-1 bg-blue-600 text-white py-4 rounded-xl font-bold hover:bg-blue-700 transition shadow-lg active:scale-95"
            >
              Sepete Ekle
            </button>
            <button className="p-4 border rounded-xl hover:bg-gray-50 transition">
              <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M4.318 6.318a4.5 4.5 0 000 6.364L12 20.364l7.682-7.682a4.5 4.5 0 00-6.364-6.364L12 7.636l-1.318-1.318a4.5 4.5 0 00-6.364 0z" />
              </svg>
            </button>
          </div>

          <div className="pt-6 text-xs text-gray-400">
            Eklenme Tarihi: {new Date(product.createdDate).toLocaleDateString('tr-TR')}
          </div>
        </div>
      </div>
    </div>
  );
}