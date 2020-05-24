import { Component, OnInit, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { Movie } from '../../shared/movie.model';
import { ApiService } from '../../shared/api.service';
import { CartService } from '../../shared/cart.service';

@Component({
  selector: 'app-detail-modal',
  templateUrl: './detail-modal.component.html',
  styleUrls: ['./detail-modal.component.css']
})
export class DetailModalComponent implements OnInit {
  @ViewChild('detailModal') modal: ModalDirective;
  movie = new Movie();

  constructor(private api: ApiService, private cart: CartService) { }

  ngOnInit() {}

  initialize(id: number): void {
    this.getMovie(id);
    this.modal.show();
  }

  // getStudio(id: number) {
  //   this.api.getStudio(id)
  //     .subscribe((data: Album) => {
  //       this.studio = data.name;
  //     },
  //       (err: Error) => {
  //         console.log('err', err);

  //       });
  // }

  getMovie(id: number) {
    this.api.getMovie(id)
      .subscribe((data: Movie) => {
        this.movie = data;
        this.movie.id = id;
        if (!data.img) {
          this.movie.img = 'https://i.ibb.co/6yFDLcr/cinema.jpg';
        }
      },
        (err: Error) => {
          console.log('err', err);
        });
  }

  addToCart(movie: Movie) {
    this.cart.add(movie);
    this.modal.hide();
  }
}
