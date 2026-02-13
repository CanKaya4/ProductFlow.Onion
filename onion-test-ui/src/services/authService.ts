import { User } from "@/types/user";

const BASE_URL = process.env.NEXT_PUBLIC_API_URL; 

export const loginRequest = async (credentials: any) => {
  const response = await fetch(`${BASE_URL}/Auth/Login`, {
    method: "POST",
    headers: { "Content-Type": "application/json" },
    body: JSON.stringify(credentials),
  });

  if (!response.ok) {
    const errorData = await response.json();
    throw new Error(errorData.message || "Giriş başarısız!");
  }

  return response.json(); 
};
export const registerRequest = async (userData: User) => {
  console.log( `İstek atılan URL:${BASE_URL}/Auth/register`);
  const response = await fetch(`${BASE_URL}/Auth/register`, {
    method: "POST",
    headers: {
      "Content-Type": "application/json",
    },
    body: JSON.stringify(userData),
  });

  if (!response.ok) {
    const errorData = await response.json();
    throw new Error(errorData.message || "Kayıt sırasında bir hata oluştu");
  }

  return await response.json();
};