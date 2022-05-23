import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { MovieDatabaseService } from './services/movie-database.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  title = 'Bookie Hols';

  constructor(private http: HttpClient, private mdbService: MovieDatabaseService) {}

  ngOnInit(): void {
    // this.http.get<any>("https://api.themoviedb.org/3/authentication/token/new?api_key=0750f28763f00a2e83ac3403aa225cad").subscribe(res => console.log(res));
    // this.mdbService.requestToken();
  }
}
