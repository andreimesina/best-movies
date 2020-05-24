import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Actor } from './actor.model';
import { Company } from './company.model';
import { Genre } from './genre.model';
import { Movie } from './movie.model';


@Injectable({
  providedIn: 'root'
})
export class ApiService {

  constructor(private http: HttpClient) {}

  header = new HttpHeaders({
    'Content-Type': 'application/json'
  });
  baseUrl = 'http://localhost:5000/api';
 
  getActor(id: number) {
    return this.http.get(this.baseUrl + '/actor/' + id.toString(), { headers: this.header });
  }

  getActors() {
    return this.http.get(this.baseUrl + '/actor', { headers: this.header });
  }

  getCompany(id: number) {
    return this.http.get(this.baseUrl + '/company/' + id.toString(), { headers: this.header });
  }

  getCompanies() {
    return this.http.get(this.baseUrl + '/company', { headers: this.header });
  }

  getGenre(id: number) {
    return this.http.get(this.baseUrl + '/genre/' + id.toString(), { headers: this.header });
  }

  getGenres() {
    return this.http.get(this.baseUrl + '/genre', { headers: this.header });
  }

  getMovie(id: number) {
    return this.http.get(this.baseUrl + '/movie/' + id.toString(), { headers: this.header });
  }

  getMovies() {
    return this.http.get(this.baseUrl + '/movie', { headers: this.header });
  }

  addActor(actor: Actor) {
    return this.http.post(this.baseUrl + '/actor', actor, { headers: this.header });
  }

  addCompany(company: Company) {
    return this.http.post(this.baseUrl + '/company', company, { headers: this.header });
  }

  addGenre(genre: Genre) {
    return this.http.post(this.baseUrl + '/genre', genre, { headers: this.header });
  }

  addMovie(movie: Movie) {
    return this.http.post(this.baseUrl + '/movie', movie, { headers: this.header });
  }

  deleteActor(id: number) {
    return this.http.delete(this.baseUrl + '/actor/' + id.toString(), { headers: this.header });
  }

  deleteCompany(id: number) {
    return this.http.delete(this.baseUrl + '/company/' + id.toString(), { headers: this.header });
  }

  deleteGenre(id: number) {
    return this.http.delete(this.baseUrl + '/genre/' + id.toString(), { headers: this.header });
  }

  deleteMovie(id: number) {
    return this.http.delete(this.baseUrl + '/movie/' + id.toString(), { headers: this.header });
  }

  editActor(actor: Actor) {
    return this.http.put(this.baseUrl + '/actor/' + actor.id.toString(), actor, { headers: this.header });
  }

  editCompany(company: Company) {
    return this.http.put(this.baseUrl + '/company/' + company.id.toString(), company, { headers: this.header });
  }

  editGenre(genre: Genre) {
    return this.http.put(this.baseUrl + '/genre/' + genre.id.toString(), genre, { headers: this.header });
  }

  editMovie(movie: Movie) {
    return this.http.put(this.baseUrl + '/movie/' + movie.id.toString(), movie, { headers: this.header });
  }

}

