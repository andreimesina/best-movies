import { Component, OnInit, ViewChild } from '@angular/core';
import { Movie } from '../shared/movie.model';
import { ApiService } from '../shared/api.service';
import { DetailModalComponent } from './detail-modal/detail-modal.component';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
  movies: Movie[] = [];
  searchText: string;
  title: string;

  @ViewChild('detailModal') detailModal: DetailModalComponent;


  constructor(private api: ApiService) { }

  ngOnInit() {
    this.api.getMovies().subscribe((data: Movie[]) => {

      for (let i = 0; i < data.length; i++) {
        this.api.getMovie(data[i].id).subscribe((info: Movie) => {
          info.id = data[i].id;
          if (!info.img) {
           info.img = 'https://i.ibb.co/6yFDLcr/cinema.jpg';
          }
        
          this.movies.push(info);
        },
          (e: Error) => {
            console.log('err', e);
          });
      }
    },
      (er: Error) => {
        console.log('err', er);
      });
  }

  showDM(id: number): void {
    this.detailModal.initialize(id);
  }

}
