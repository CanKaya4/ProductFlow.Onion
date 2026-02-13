"use client";
import Link from "next/link";
import { useRouter } from "next/navigation";
import { RootState } from "@/stores/store";
import { useSelector } from "react-redux";
import {useTranslations,useLocale} from 'next-intl';


export default function Navbar() {
  const router = useRouter();
  const locale = useLocale(); 
  const t = useTranslations('Navbar');
  const basketItems = useSelector((state: RootState) => state.basket.items);
  const totalItems = basketItems.reduce((total, item) => total + item.quantity, 0);

  const handleLogout = () => {
    localStorage.removeItem("token");
    router.push("/login"); 
  };

  return (
    <nav className="bg-white border-b sticky top-0 z-50">
      <div className="max-w-7xl mx-auto px-4 sm:px-6 lg:px-8">
        <div className="flex justify-between h-16 items-center">
          <div className="flex-shrink-0 flex items-center">
          
            <Link href="/" className="text-2xl font-bold text-blue-600 tracking-tight">
              Product<span className="text-gray-900">Flow</span>
            </Link>
          </div>
          
          <div className="hidden md:flex space-x-8 text-gray-600 font-medium">
            <Link href="/" className="hover:text-blue-600 transition">{t('home')}</Link>
          </div>

          <div className="flex items-center space-x-4">
            <Link href="/basket" className="relative p-2 text-gray-600 hover:text-blue-600">
              <span className="absolute top-0 right-0 bg-blue-600 text-white text-xs rounded-full h-4 w-4 flex items-center justify-center">
                {totalItems}
              </span>
              <svg xmlns="http://www.w3.org/2000/svg" className="h-6 w-6" fill="none" viewBox="0 0 24 24" stroke="currentColor">
                <path strokeLinecap="round" strokeLinejoin="round" strokeWidth={2} d="M16 11V7a4 4 0 00-8 0v4M5 9h14l1 12H4L5 9z" />
              </svg>
            </Link>
            
            <button 
              onClick={handleLogout}
              className="bg-gray-100 text-gray-700 px-4 py-2 rounded-lg text-sm font-medium hover:bg-gray-200 transition"
            >
              {t('logout')}
            </button>
          </div>
        </div>
      </div>
    </nav>
  );
}