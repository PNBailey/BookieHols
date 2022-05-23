import { Component, OnInit } from '@angular/core';
import { environment } from 'src/environments/environment';
import { MovieDatabaseService } from '../services/movie-database.service';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {

  constructor(private mdbService: MovieDatabaseService) { }

  ngOnInit(): void {
  }

}
