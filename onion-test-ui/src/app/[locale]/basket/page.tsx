"use client";
import { useSelector, useDispatch } from "react-redux";
import { RootState } from "@/stores/store";import Image from "next/image";
import Link from "next/link";
import { addToBasket,decrementQuantity,removeFromBasket } from "@/stores/features/basketSlice";
import {useTranslations} from 'next-intl';

export default function BasketPage() {
  const { items } = useSelector((state: RootState) => state.basket);
  const dispatch = useDispatch();
    const t = useTranslations('Basket');

  const totalPrice = items.reduce((total, item) => total + (item.price * item.quantity), 0);

  if (items.length === 0) {
    return (
      <div className="max-w-7xl mx-auto px-4 py-20 text-center">
        <h2 className="text-2xl font-bold">Sepetiniz şu an boş.</h2>
        <Link href="/tr" className="text-blue-600 mt-4 inline-block hover:underline">Alışverişe Devam Et</Link>
      </div>
    );
  }

  return (
    <div className="max-w-7xl mx-auto px-4 py-12">
      <h1 className="text-3xl font-extrabold mb-8 text-black">{t("myCart")}</h1>
      
      <div className="grid grid-cols-1 lg:grid-cols-3 gap-12">
        <div className="lg:col-span-2 space-y-4">
          {items.map((item) => (
            <div key={item.id} className="flex items-center gap-4 p-4 border rounded-xl bg-white shadow-sm">
              <div className="relative h-24 w-24 flex-shrink-0">
                <Image 
                  src={item.imageUrl?.startsWith("http") ? item.imageUrl : "https://images.pexels.com/photos/1036856/pexels-photo-1036856.jpeg"} 
                  alt={item.name} fill className="object-cover rounded-md"
                />
              </div>
              
              <div className="flex-1">
                <h3 className="font-bold text-gray-800">{item.name}</h3>
                <p className="text-blue-600 font-bold">{item.price.toLocaleString('tr-TR')} TL</p>
              </div>

              <div className="flex items-center gap-3 bg-gray-100 p-2 rounded-lg">
                <button onClick={() => dispatch(decrementQuantity(item.id))} className="px-2 font-bold">-</button>
                <span className="font-bold w-4 text-center">{item.quantity}</span>
                <button onClick={() => dispatch(addToBasket(item))} className="px-2 font-bold">+</button>
              </div>

              <button 
                onClick={() => dispatch(removeFromBasket(item.id))}
                className="text-red-500 hover:text-red-700 p-2"
              >
                <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                  <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M19 7l-.867 12.142A2 2 0 0116.138 21H7.862a2 2 0 01-1.995-1.858L5 7m5 4v6m4-6v6m1-10V4a1 1 0 00-1-1h-4a1 1 0 00-1 1v3M4 7h16" />
                </svg>
              </button>
            </div>
          ))}
        </div>

        <div className="bg-gray-50 p-6 rounded-xl border h-fit">
          <h2 className="text-xl font-bold mb-4">{t("orderSummary")}</h2>
          <div className="flex justify-between mb-2">
            <span>{t("totalProduct")}</span>
            <span>{items.reduce((acc, curr) => acc + curr.quantity, 0)}</span>
          </div>
          <div className="flex justify-between text-xl font-bold border-t pt-4">
            <span>{t("totalAmount")}</span>
            <span className="text-blue-600">{totalPrice.toLocaleString('tr-TR')} TL</span>
          </div>
          <button className="w-full bg-green-600 text-white mt-6 py-3 rounded-xl font-bold hover:bg-green-700 transition">
            {t("orderSummary")}
          </button>
        </div>
      </div>
    </div>
  );
}