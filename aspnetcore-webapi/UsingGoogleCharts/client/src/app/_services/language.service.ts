import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { map } from 'rxjs/operators';

@Injectable({
  providedIn: 'root',
})
export class LanguageService {
  constructor(private http: HttpClient) {}

  private languageApiUrl = environment.apiUrl + 'languages/GetLanguageStats';

  GetLanguageStatistics() {
    return this.http.get<any>(this.languageApiUrl).pipe(
      map((result) => {
        return result;
      })
    );
  }
}
