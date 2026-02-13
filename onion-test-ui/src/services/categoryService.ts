const BASE_URL = process.env.NEXT_PUBLIC_API_URL;
export const getCategories = async () => {
  const token = localStorage.getItem("token");

  const response = await fetch(`${BASE_URL}/Categories`, { 
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      "Authorization": `Bearer ${token}`
    }
  });

  if (!response.ok) return []; 
  return response.json();
};