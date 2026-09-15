import { Routes } from '@angular/router';

import { Home } from './home/home';
import { NotFound } from './error-pages/not-found/not-found';

export const routes: Routes = [
  { path: 'home', component: Home },
  { path: '404', component: NotFound },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/404' }
];
