import { Component, EventEmitter, OnInit, Output, ViewChild } from '@angular/core';
import { ModalDirective } from 'ngx-bootstrap/modal';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { Actor } from '../../shared/Actor.model';
import { ApiService } from '../../shared/api.service';

@Component({
  selector: 'app-edit-actor-modal',
  templateUrl: './edit-actor-model.component.html',
  styleUrls: ['./edit-actor-modal.component.css']
})
export class EditActorModalComponent {
  @ViewChild('editActorModal') modal: ModalDirective;
  @Output() change: EventEmitter<string> = new EventEmitter<string>();
  editActorForm: FormGroup;
  currentActor = new Actor();

  constructor(public fb: FormBuilder, private api: ApiService) { }

  initialize(id: number): void {
    this.modal.show();
    this.api.getActor(id)
      .subscribe((data: Actor) => {
        this.currentActor = data;
        this.currentActor.id = id;
        this.initializeFrom(this.currentActor);
      },
        (error: Error) => {
          console.log('err', error);

        });
  }

  initializeFrom(currentActor: Actor) {
    this.editActorForm = this.fb.group({
      name: [currentActor.name, Validators.required],
      movieId: [currentActor.movieId, Validators.required]
    });
  }

  editActor() {
    const editedActor = new Actor({
      id: this.currentActor.id,
      name: this.editActorForm.value.name,
      movieId: this.editActorForm.value.movieId
    });

    this.api.editActor(editedActor)
      .subscribe(() => {
        this.change.emit('actor');
        this.modal.hide();
      },
        (error: Error) => {
          console.log('err', error);
        });
  }
}