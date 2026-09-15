import { Routes } from '@angular/router';

import { OwnerList } from './owner-list/owner-list';
import { OwnerDetails } from './owner-details/owner-details';
import { OwnerCreate } from './owner-create/owner-create';
import { OwnerUpdate } from './owner-update/owner-update';
import { OwnerDelete } from './owner-delete/owner-delete';

export const routes: Routes = [
  { path: 'list', component: OwnerList },
  { path: 'details/:id', component: OwnerDetails },
  { path: 'create', component: OwnerCreate },
  { path: 'update/:id', component: OwnerUpdate },
  { path: 'delete/:id', component: OwnerDelete }
];
