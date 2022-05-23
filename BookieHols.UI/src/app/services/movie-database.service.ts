import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Router } from '@angular/router';
import { switchMap, tap } from 'rxjs/operators';
import { environment } from 'src/environments/environment';
import { TokenRequest } from '../Models/tokenRequest';

@Injectable({
  providedIn: 'root'
})
export class MovieDatabaseService {
  apiKey = environment.movieDatabaseApiKey;

  constructor(private http: HttpClient, private route: Router) { }

  /**
   * @remarks
   * Retrieves a request token from the Movie Database api
   */
  requestToken() {
    this.http.get<TokenRequest>(`https://api.themoviedb.org/3/authentication/token/new?api_key=${this.apiKey}`).pipe(
      tap((tokenRequest: TokenRequest) => {
        environment.tokenRequest = tokenRequest;
        this.authenticateUser(tokenRequest);
      })).subscribe();
  }

  /**
   * @remarks
   * Gets an access token once the user has approved the request to access the movie database
   */
  getAccessToken(tokenRequest: TokenRequest) {
    this.http.post<any>(`https://api.themoviedb.org/4/auth/access_token?api_key=${this.apiKey}`, {
      request_token: tokenRequest.request_token
    }).subscribe(res => console.log(res));
  }


  /**
   * @remarks
   * Authenticates a user on the Movie Database using the request token
   * 
   * @param tokenRequest
   * The token to authenticate the users session with
   */
  private authenticateUser(tokenRequest: TokenRequest) {
    window.location.href = `https://www.themoviedb.org/authenticate/${tokenRequest.request_token}?redirect_to=http://localhost:4200/home`;
  }


}
