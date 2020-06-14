import { Component, OnInit, ViewChild } from '@angular/core';
import { NgForm } from '@angular/forms';
import {ListingService } from '../listing.service'

@Component({
  selector: 'app-add',
  templateUrl: './add.component.html',
  styleUrls: ['./add.component.css']
})
export class AddComponent {

  constructor(private listingService: ListingService) { }

  @ViewChild('addListingForm', { static: true }) from: NgForm

  createListingHandler(data){
    this.listingService.create(data).subscribe(res => {
      console.log(res)
    });
    // this.from.reset();
  }

}
