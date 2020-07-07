import { Component, OnInit } from '@angular/core';
import { OfferService } from '../offer.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IOffer } from 'src/app/shared/Interfaces/IOffer';

@Component({
  selector: 'app-all',
  templateUrl: './all.component.html',
  styleUrls: ['./all.component.css']
})
export class AllComponent implements OnInit {

  allOffers: Array<IOffer>
  constructor(
    private offerService: OfferService,
    private activatedRoute: ActivatedRoute,
    private router: Router) {}

  ngOnInit() {
    this.allOffers = new Array();
    this.offerService.getAllOffersForListing(this.activatedRoute.snapshot.params.id)
    .subscribe(res => {
      this.allOffers = res
    });
  }


  acceptOffer(id){
    console.log(id);
    
    this.offerService.accept(id).subscribe(res => {
      this.router.navigate(['listing/all']);
    })
  }

}
