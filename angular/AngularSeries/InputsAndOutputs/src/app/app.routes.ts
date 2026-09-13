import { Routes } from '@angular/router';

import { Home } from './home/home';
import { NotFound } from './error-pages/not-found/not-found';
import { InternalServer } from './error-pages/internal-server/internal-server';

export const routes: Routes = [
  { path: 'home', component: Home },
  { path: 'owner', loadChildren: () => import('./owner/owner.routes').then(m => m.routes) },
  { path: '404', component: NotFound },
  { path: '500', component: InternalServer },
  { path: '', redirectTo: '/home', pathMatch: 'full' },
  { path: '**', redirectTo: '/404' }
];
