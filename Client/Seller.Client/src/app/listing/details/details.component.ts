import { Component, OnInit } from '@angular/core';
import { ListingService } from '../listing.service';
import { UserService } from 'src/app/user/user.service';
import { ActivatedRoute, Router } from '@angular/router';
import { IListing } from 'src/app/shared/Interfaces/IListing';

@Component({
  selector: 'app-details',
  templateUrl: './details.component.html',
  styleUrls: ['./details.component.css']
})
export class DetailsComponent implements OnInit {

  selectedListing: IListing;
  token: string;
  userId: string

  constructor(
    private listingService: ListingService, 
    private userService: UserService,
    private activatedRoute: ActivatedRoute,
    private router: Router
    ) { }

  deleteHandler(id: string){
    this.listingService.delete(id).subscribe(res => {
      this.router.navigate(['listing/all']);
    })
  }

  sendRequestHandler(){
  //   var currentRequest: IRequest;
  //   var date = new Date();
  //   currentRequest = {
  //     requestedOn: date.getTime(),
  //     name: this.selectedListing.title,
  //     requestedBy: this.userServiceLH.user.username,
  //     email: this.userServiceLH.user.email,
  //     postedBy: this.selectedListing.postedBy   
  //   };
  //  // console.log(currentRequest);
    
  //  this.userServiceLH.saveRequest(currentRequest)
  }

  ngOnInit() {
    this.listingService.details(this.activatedRoute.snapshot.params.id)
    .subscribe(listings => {
      this.listingService.setCurrentListingSeller(listings.sellerId);
      this.selectedListing = listings
      this.userId = this.userService.getUserId()
      this.token = this.userService.getToken()
    });
  }

  
}
