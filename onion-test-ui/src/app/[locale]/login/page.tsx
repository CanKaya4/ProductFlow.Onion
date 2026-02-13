"use client";
import { useState } from "react";
import { useRouter } from "next/navigation";
import { loginRequest } from "@/services/authService";
import Link from "next/link";
import { useLocale } from "next-intl";

export default function LoginPage() {
  const [username, setUsername] = useState("");
  const [password, setPassword] = useState("");
  const [error, setError] = useState("");
  const router = useRouter();
  const locale = useLocale();

const handleSubmit = async (e: React.FormEvent) => {
  e.preventDefault();
  setError("");

  try {
    const data = await loginRequest({ username, password });
    
    localStorage.setItem("token", data.token);
    
    document.cookie = `token=${data.token}; path=/; max-age=604800; SameSite=Lax`;

   router.push(`/${locale}/`);
  } catch (err: any) {
    setError(err.message);
  }
};

  return (
    <div className="flex min-h-screen items-center justify-center bg-gray-100 px-4">
      <div className="bg-white shadow-xl rounded-2xl w-full max-w-md overflow-hidden">
        <form onSubmit={handleSubmit} className="p-8">
          <h1 className="text-3xl font-extrabold mb-2 text-center text-gray-800">Giriş Yap</h1>
          <p className="text-center text-gray-500 mb-8 text-sm">Devam etmek için lütfen bilgilerinizi girin.</p>
          
          {error && (
            <div className="bg-red-50 border-l-4 border-red-500 p-4 mb-6">
              <p className="text-red-700 text-sm">{error}</p>
            </div>
          )}
          
          <div className="space-y-4">
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Kullanıcı Adı</label>
              <input
                type="text"
                placeholder="Kullanıcı adınızı girin"
                className="w-full p-3 border border-gray-300 rounded-lg text-black outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent transition"
                value={username}
                onChange={(e) => setUsername(e.target.value)}
                required
              />
            </div>
            
            <div>
              <label className="block text-sm font-medium text-gray-700 mb-1">Şifre</label>
              <input
                type="password"
                placeholder="••••••••"
                className="w-full p-3 border border-gray-300 rounded-lg text-black outline-none focus:ring-2 focus:ring-blue-500 focus:border-transparent transition"
                value={password}
                onChange={(e) => setPassword(e.target.value)}
                required
              />
            </div>
          </div>
          
          <button 
            type="submit" 
            className="w-full bg-blue-600 text-white p-3 rounded-lg font-bold hover:bg-blue-700 transform transition active:scale-[0.98] mt-8"
          >
            Giriş Yap
          </button>

          <div className="mt-6 text-center">
            <p className="text-gray-600 text-sm">
              Hesabınız yok mu?{" "}
              <Link 
                href="/tr/register" 
                className="text-blue-600 font-bold hover:text-blue-800 hover:underline transition"
              >
                Üye Ol
              </Link>
            </p>
          </div>
        </form>
      </div>
    </div>
  );
}