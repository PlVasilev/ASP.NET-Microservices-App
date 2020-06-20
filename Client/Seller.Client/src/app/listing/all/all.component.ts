import { Component, OnInit, ViewChild } from '@angular/core';
import { ListingService } from '../listing.service';
import { Router } from '@angular/router';
import { NgForm } from '@angular/forms';
import { IListing } from 'src/app/shared/Interfaces/IListing';

@Component({
  selector: 'app-all',
  templateUrl: './all.component.html',
  styleUrls: ['./all.component.css']
})
export class AllComponent implements OnInit {

  listingId = null;
  allListings: Array<IListing>

  constructor(private listingService: ListingService, private router: Router) { }

  ngOnInit() {
       this.listingService.getListings().subscribe(listings => {
         this.allListings = listings
       });
  }

  ngOnChange() {
    this.listingService.getListings().subscribe(listings => {
      this.allListings = listings
    });
}

  detailsIdHandler(listingId: string){
    this.router.navigate([`/listing/details/${listingId}`])
  }
  
  @ViewChild('searchFrom', {static: true}) from: NgForm
  // @ViewChild('searchFrom', { static: true }) from: NgForm
  
   searchFormHandler(value){  
     // this.listingService.searchListings(value);
   }

  // detailsHandler(listing: IListing){
  //   this.listingService.selectedListing = listing;
  // }

  fromChild(event){
    this.listingId = event;
  }
}
