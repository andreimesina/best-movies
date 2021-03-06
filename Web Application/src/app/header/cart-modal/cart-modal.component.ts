import { Component, OnInit, ViewChild } from '@angular/core';
import { Movie } from 'src/app/shared/movie.model';
import { CartService } from 'src/app/shared/cart.service';
import { ModalDirective } from 'ngx-bootstrap/modal';

@Component({
  selector: 'app-cart-modal',
  templateUrl: './cart-modal.component.html',
  styleUrls: ['./cart-modal.component.css']
})
export class CartModalComponent implements OnInit {
  @ViewChild('cartModal') modal: ModalDirective;
  movies: Movie[] = [];


  constructor(private cartService: CartService) { }

  ngOnInit(): void {
  }

  initialize() {
    this.modal.show();
    this.movies = this.cartService.get();
  }

  delete(id: number) {
    this.movies.splice(id, 1);
  }
}
