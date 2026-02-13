import { NextIntlClientProvider } from 'next-intl';
import { getMessages } from 'next-intl/server';
import { Providers } from '@/stores/Providers'; // RTK Provider'ın
import Navbar from "@/components/Navbar";
import Footer from "@/components/Footer";
 import "./globals.css";
 import { headers } from 'next/headers';

export default async function LocaleLayout(props: {
  children: React.ReactNode;
  params: Promise<{ locale: string }>;
}) {
  const { locale } = await props.params;
  const messages = await getMessages();

  return (
    <html lang={locale}>
      <body className="flex flex-col min-h-screen">
      
        <Providers> 
          <NextIntlClientProvider locale={locale} messages={messages}>
            <Navbar />
            <main className="flex-grow">
              {props.children}
            </main>
            <Footer />
          </NextIntlClientProvider>
        </Providers>
      </body>
    </html>
  );
}