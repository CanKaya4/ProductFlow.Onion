import { getRequestConfig } from 'next-intl/server';

export default getRequestConfig(async (props) => {
  // Turbopack için locale'i güvenli yoldan alıyoruz
  const locale = (await props.requestLocale) || 'tr'; 

  return {
    locale,
    messages: (await import(`@/messages/${locale}.json`)).default
  };
});