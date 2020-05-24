import { Component, EventEmitter, Output, ViewChild } from '@angular/core';

import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ApiService } from '../../shared/api.service';
import { Movie } from '../../shared/movie.model';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-edit-movie-modal',
  templateUrl: './edit-movie-modal.component.html',
  styleUrls: ['./edit-movie-modal.component.css']
})
export class EditMovieModalComponent {
  @ViewChild('editMovieModal') modal: ModalDirective;
  @Output() change: EventEmitter<string> = new EventEmitter<string>();
  editMovieForm: FormGroup;
  currentMovie = new Movie();

  constructor(public fb: FormBuilder, private api: ApiService) { }

  initialize(id: number): void {
    this.modal.show();
    this.api.getMovie(id)
      .subscribe((data: Movie) => {
        this.currentMovie = data;
        this.currentMovie.id = id;
        this.initializeFrom(this.currentMovie);
      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  initializeFrom(currentMovie: Movie) {
    this.editMovieForm = this.fb.group({
      title: [currentMovie.title, Validators.required],
      releaseDate: [currentMovie.releaseDate, Validators.required],
      runTime: [currentMovie.runtime, Validators.required],
      artistId: ['', Validators.required],
      companyId: ['', Validators.required],
      genreId: ['', Validators.required],
      vote: [currentMovie.vote, Validators.required],
      img: [currentMovie.img],
    });
  }

  editMovie() {
    const editedMovie = new Movie({
      id: this.currentMovie.id,
      title: this.editMovieForm.value.title,
      releaseDate: this.editMovieForm.value.releaseDate,
      runtime: this.editMovieForm.value.runtime,
      vote: this.editMovieForm.value.vote,
      artistId: this.editMovieForm.value.artistId,
      companyId: this.editMovieForm.value.companyId,
      genreId: this.editMovieForm.value.genreId,
      img: this.editMovieForm.value.img
    });

    this.api.editMovie(editedMovie)
      .subscribe(() => {
        this.change.emit('movie');
        this.modal.hide();
      },
        (error: Error) => {
          console.log('err', error);
        });
  }

  transformInNumberArray(string: string) {
    return JSON.parse('[' + string + ']');
  }

}