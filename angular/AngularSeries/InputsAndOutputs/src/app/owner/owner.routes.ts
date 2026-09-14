import { Routes } from '@angular/router';

import { OwnerList } from './owner-list/owner-list';
import { OwnerDetails } from './owner-details/owner-details';

export const routes: Routes = [
  { path: 'list', component: OwnerList },
  { path: 'details/:id', component: OwnerDetails }
];
