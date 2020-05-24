import { Component, OnInit, ViewChild } from '@angular/core';
import { ApiService } from '../shared/api.service';
import { Actor } from '../shared/actor.model';
import { Company } from '../shared/company.model';
import { Movie } from '../shared/movie.model';
import { EditActorModalComponent } from './edit-actor-modal/edit-actor-modal.component';
import { EditCompanyModalComponent } from './edit-company-modal/edit-company-modal.component';
import { EditMovieModalComponent } from './edit-movie-modal/edit-movie-modal.component';

@Component({
  selector: 'app-edit',
  templateUrl: './edit.component.html',
  styleUrls: ['./edit.component.css']
})
export class EditComponent implements OnInit {
  movies: Movie[] = [];
  actors: Actor[] = [];
  companies: Company[] = [];

  @ViewChild('editActorModal') editActorModal: EditActorModalComponent;
  @ViewChild('editCompanyModal') editCompanyModal: EditCompanyModalComponent;
  @ViewChild('editMovieModal') editMovieModal: EditMovieModalComponent;
  
  constructor(private api: ApiService) { }
  
  ngOnInit() {
    this.getMovies();
    this.getActors();
    this.getCompanies();
  }

  getMovies() {
    this.api.getMovies()
      .subscribe((data: Movie[]) => {
        this.movies = [];

        for (let i = 0; i < data.length; i++) {
          this.api.getMovie(data[i].id)
            .subscribe((info: Movie) => {
              info.id = data[i].id;
              this.movies.push(info);
            },
              (e: Error) => {
                console.log('err', e);
              });
        }

      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  getActors() {
    this.api.getActors()
      .subscribe((data: Actor[]) => {
        this.actors = data;
      },
        (error: Error) => {
          console.log('err', error);
        });
  }

  getCompanies() {
    this.api.getCompanies()
      .subscribe((data: Company[]) => {
        this.companies = data;
      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  deleteMovie(id: number) {
    this.api.deleteMovie(id)
      .subscribe(() => {
        this.getMovies();
      },
        (error: Error) => {
          console.log(error);
        });
  }

  deleteActor(id: number) {
    this.api.deleteActor(id)
      .subscribe(() => {
        this.getActors();
      },
        (error: Error) => {
          console.log(error);
        });
  }

  deleteCompany(id: number) {
    this.api.deleteCompany(id)
      .subscribe(() => {
        this.getCompanies();
      },
        (error: Error) => {
          console.log(error);
        });
  }

  showM1(id: number) {
    this.editMovieModal.initialize(id);
  }

  showM2(id: number) {
    this.editActorModal.initialize(id);
  }

  showM3(id: number) {
    this.editCompanyModal.initialize(id);
  }

  onEditFinished(event: string) {
    if (event === 'actor') {
      this.getActors();
    }
    if (event === 'company') {
      this.getCompanies();
    }
    if (event === 'movie') {
      this.getMovies();
    }
  }
}