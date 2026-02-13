"use client";
import { useTranslations } from 'next-intl';

interface ProductFilterProps {
  categories: any[];
  categoryId: string;
  setCategoryId: (id: string) => void;
  minPrice: number | "";
  setMinPrice: (price: number | "") => void;
  maxPrice: number | "";
  setMaxPrice: (price: number | "") => void;
  sortOrder: string;
  setSortOrder: (order: "asc" | "desc" | "") => void;
  onFetch: () => void;
}

export default function ProductFilter({
  categories, categoryId, setCategoryId,
  minPrice, setMinPrice, maxPrice, setMaxPrice,
  sortOrder, setSortOrder, onFetch
}: ProductFilterProps) {
  const t = useTranslations('Filter');

  return (
    <aside className="w-full md:w-64 space-y-6">
      <div className="bg-white p-6 rounded-xl border shadow-sm">
        <h2 className="text-lg font-bold mb-4 text-black">{t("Filtering")}</h2>
        
        <div className="space-y-4">
          {/* Kategori Seçimi */}
          <div>
            <label className="text-sm font-semibold text-gray-700">{t("Category")}</label>
            <select 
              className="w-full p-2 border rounded mt-1 text-black bg-white focus:ring-2 focus:ring-blue-500 outline-none"
              value={categoryId}
              onChange={(e) => setCategoryId(e.target.value)}
            >
              <option value="">{t("allCategory")}</option>
              {categories.map((cat) => (
                <option key={cat.id} value={cat.id}>{cat.name}</option>
              ))}
            </select>
          </div>

          {/* Fiyat Aralığı */}
          <div className="grid grid-cols-2 gap-2">
            <div>
              <label className="text-xs font-medium text-gray-500">{t("minPrice")}</label>
              <input 
                type="number" 
                className="w-full p-2 border rounded mt-1 text-black text-sm" 
                value={minPrice} 
                onChange={(e) => setMinPrice(e.target.value === "" ? "" : Number(e.target.value))}
              />
            </div>
            <div>
              <label className="text-xs font-medium text-gray-500">{t("maxPrice")}</label>
              <input 
                type="number" 
                className="w-full p-2 border rounded mt-1 text-black text-sm"
                value={maxPrice}
                onChange={(e) => setMaxPrice(e.target.value === "" ? "" : Number(e.target.value))}
              />
            </div>
          </div>

          {/* Sıralama */}
          <div className="pt-4 border-t mt-4">
            <label className="text-sm font-semibold text-gray-700">Sıralama</label>
            <select 
              className="w-full p-2 border rounded mt-1 text-black bg-white text-sm"
              value={sortOrder}
              onChange={(e) => setSortOrder(e.target.value as "asc" | "desc" | "")}
            >
              <option value="">Önerilen</option>
              <option value="asc">Fiyat: Düşükten Yükseğe</option>
              <option value="desc">Fiyat: Yüksekten Düşüğe</option>
            </select>
          </div>

          <button 
            onClick={onFetch}
            className="w-full bg-blue-600 text-white py-2 rounded-lg font-bold hover:bg-blue-700 transition shadow-md"
          >
            {t("showResult")}
          </button>
        </div>
      </div>
    </aside>
  );
}