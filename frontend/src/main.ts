import { enableProdMode } from '@angular/core';
import { platformBrowserDynamic } from '@angular/platform-browser-dynamic';
import { BASE_URL } from './app/core/Swagger';
import { AppModule } from './app/app.module';
import { environment } from './environments/environment';

if (environment.production) {
  enableProdMode();
}
export function getBaseUrl(): string {
  return 'https://localhost:7113/';
}

export function getApiBaseUrl() {
  var url = getBaseUrl();
  if (url && url[url.length - 1] == '/') {
    return url.substring(0, url.length - 1);
  }

  return url;
}

const providers = [
  { provide: 'BASE_URL', useFactory: getBaseUrl, deps: [] },
  { provide: BASE_URL, useFactory: getApiBaseUrl, deps: [] },
];

platformBrowserDynamic(providers)
  .bootstrapModule(AppModule)
  .catch((err) => console.error(err));
