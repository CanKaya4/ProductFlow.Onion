import createMiddleware from 'next-intl/middleware';
import { NextRequest, NextResponse } from 'next/server';

const intlMiddleware = createMiddleware({
  locales: ['tr', 'en'],
  defaultLocale: 'tr',
  localePrefix: 'always'
});

export default function middleware(request: NextRequest) {
  const { pathname } = request.nextUrl;

  if (
    pathname.startsWith('/_next') || 
    pathname.includes('/api/') ||
    pathname.includes('.')
  ) {
    return NextResponse.next();
  }

  const response = intlMiddleware(request);

  const token = request.cookies.get('token')?.value;
  
  const segments = pathname.split('/');
  const currentLocale = ['tr', 'en'].includes(segments[1]) ? segments[1] : 'tr';
  
  const isAuthPage = pathname.includes('/login') || pathname.includes('/register');

  if (!token && !isAuthPage && pathname !== '/') {
     const loginUrl = new URL(`/${currentLocale}/login`, request.url);
     return NextResponse.redirect(loginUrl);
  }

  if (token && isAuthPage) {
    return NextResponse.redirect(new URL(`/${currentLocale}`, request.url));
  }

  return response;
}

export const config = {
  matcher: ['/', '/(tr|en)/:path*', '/((?!api|_next|_vercel|.*\\..*).*)']
};