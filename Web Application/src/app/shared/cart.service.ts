
import {Injectable} from '@angular/core';
import {Movie} from './movie.model';

@Injectable({
  providedIn: 'root'
})
export class CartService {
  movies: Movie[] =[];


  constructor() {

  }

  add(movie: Movie){
    this.movies.push(movie);

  }

  get() {
    return this.movies;
  }


}
