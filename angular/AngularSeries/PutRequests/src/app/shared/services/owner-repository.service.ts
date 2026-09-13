import { HttpClient } from '@angular/common/http';
import { Service, inject } from '@angular/core';

import { Owner } from '../../_interfaces/owner.model';
import { OwnerForCreation } from '../../_interfaces/ownerForCreation.model';
import { OwnerForUpdate } from '../../_interfaces/ownerForUpdate.model';
import { EnvironmentUrlService } from './environment-url.service';

@Service()
export class OwnerRepositoryService {
  private http = inject(HttpClient);
  private envUrl = inject(EnvironmentUrlService);

  public getOwners(route: string) {
    return this.http.get<Owner[]>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public getOwner(route: string) {
    return this.http.get<Owner>(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  public createOwner(route: string, owner: OwnerForCreation) {
    return this.http.post<Owner>(this.createCompleteRoute(route, this.envUrl.urlAddress), owner);
  }

  public updateOwner(route: string, owner: OwnerForUpdate) {
    return this.http.put(this.createCompleteRoute(route, this.envUrl.urlAddress), owner);
  }

  public deleteOwner(route: string) {
    return this.http.delete(this.createCompleteRoute(route, this.envUrl.urlAddress));
  }

  private createCompleteRoute(route: string, envAddress: string) {
    return `${envAddress}/${route}`;
  }
}
