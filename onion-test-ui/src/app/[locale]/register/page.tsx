"use client";
import { useState } from "react";
import { useRouter } from "next/navigation";
import { registerRequest } from "@/services/authService";
import Link from "next/link";
import { User } from "@/types/user";

export default function RegisterPage() {
  const [formData, setFormData] = useState<User>({
  firstName: "",
  lastName: "",
  username: "",
  email: "",
  password: ""
});
  const [error, setError] = useState("");
  const [loading, setLoading] = useState(false);
  const router = useRouter();

  const handleSubmit = async (e: React.FormEvent) => {
    e.preventDefault();
    setError("");
    setLoading(true);

    try {

      await registerRequest(formData);
      

      alert("Kayıt başarılı! Giriş yapabilirsiniz.");
      router.push("/tr/login");
    } catch (err: any) {
      setError(err.message);
    } finally {
      setLoading(false);
    }
  };

  return (
    <div className="flex min-h-screen items-center justify-center bg-gray-100 px-4">
      <form onSubmit={handleSubmit} className="p-8 bg-white shadow-lg rounded-2xl w-full max-w-md">
        <h1 className="text-2xl font-bold mb-6 text-center text-black">Yeni Hesap Oluştur</h1>
        
        {error && <p className="bg-red-100 text-red-600 p-3 rounded-lg text-sm mb-4">{error}</p>}
        
        <div className="space-y-4">
          <input
            type="text"
            placeholder="Adınız"
            className="w-full p-3 border rounded-lg text-black outline-none focus:ring-2 focus:ring-blue-500"
            onChange={(e) => setFormData({...formData, firstName: e.target.value})}
            required
          />
          <input
            type="text"
            placeholder="Soyadınız"
            className="w-full p-3 border rounded-lg text-black outline-none focus:ring-2 focus:ring-blue-500"
            onChange={(e) => setFormData({...formData, lastName: e.target.value})}
            required
          />
            <input
            type="text"
            placeholder="Kullanıcı Adı"
            className="w-full p-3 border rounded-lg text-black outline-none focus:ring-2 focus:ring-blue-500"
            onChange={(e) => setFormData({...formData, username: e.target.value})}
            required
          />
          <input
            type="email"
            placeholder="E-posta"
            className="w-full p-3 border rounded-lg text-black outline-none focus:ring-2 focus:ring-blue-500"
            onChange={(e) => setFormData({...formData, email: e.target.value})}
            required
          />
          <input
            type="password"
            placeholder="Şifre"
            className="w-full p-3 border rounded-lg text-black outline-none focus:ring-2 focus:ring-blue-500"
            onChange={(e) => setFormData({...formData, password: e.target.value})}
            required
          />
        </div>

        <button 
          type="submit" 
          disabled={loading}
          className="w-full bg-blue-600 text-white p-3 rounded-lg font-bold hover:bg-blue-700 transition mt-6 disabled:bg-gray-400"
        >
          {loading ? "Kaydediliyor..." : "Kayıt Ol"}
        </button>

        <p className="mt-4 text-center text-sm text-gray-600">
          Zaten hesabınız var mı?{" "}
          <Link href="/tr/login" className="text-blue-600 font-bold hover:underline">Giriş Yap</Link>
        </p>
      </form>
    </div>
  );
}