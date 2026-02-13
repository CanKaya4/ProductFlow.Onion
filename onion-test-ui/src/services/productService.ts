const BASE_URL = process.env.NEXT_PUBLIC_API_URL; 

export const getProducts = async (filters: {
  minPrice?: number;
  maxPrice?: number;
  categoryId?: string;
  pageNumber?: number;
  pageSize?: number;
}) => {
  const token = localStorage.getItem("token");
  const params = new URLSearchParams();

  if (filters.minPrice) params.append("MinPrice", filters.minPrice.toString());
  if (filters.maxPrice) params.append("MaxPrice", filters.maxPrice.toString());
  if (filters.categoryId) params.append("CategoryId", filters.categoryId);
  params.append("PageNumber", (filters.pageNumber || 1).toString());
  params.append("PageSize", (filters.pageSize || 10).toString());

  const response = await fetch(`${BASE_URL}/Products?${params.toString()}`, {
    method: "GET",
    headers: {
      "Content-Type": "application/json",
      "Authorization": `Bearer ${token}`
    }
  });

  if (!response.ok) throw new Error("Filtreleme sırasında hata oluştu.");
  return response.json();
};
export const getProductBySlug = async (slug: string) => {
  let token: string | undefined;


  if (typeof window === "undefined") {
    const { cookies } = await import("next/headers");
    const cookieStore = await cookies();
    token = cookieStore.get("token")?.value;
  } else {
    token = localStorage.getItem("token") || undefined;
  }

  const response = await fetch(`${BASE_URL}/Products/${slug}`, {
    method: "GET",
    headers: {
      "Authorization": `Bearer ${token}`,
      "Content-Type": "application/json"
    },
    next: { revalidate: 3600 } 
  });

  if (!response.ok) throw new Error(`API Hatası: ${response.status}`);
  return response.json();
};