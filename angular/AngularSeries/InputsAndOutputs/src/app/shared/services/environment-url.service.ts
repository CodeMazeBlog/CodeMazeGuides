import { Service } from '@angular/core';

import { environment } from '../../../environments/environment';

@Service()
export class EnvironmentUrlService {
  urlAddress: string = environment.urlAddress;
}
