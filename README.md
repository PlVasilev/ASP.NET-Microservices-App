# ASP.NET-Microservices-App - Seller
##### ASP.NET Core Server + Angular Client

### Seller APP Idea
This is **extreamly** simple app for Listing Properties on the market,
make offfers and make deal for them.

## App content
- Clent App Angular
- Server Apps ASP.NET 3.1 - 9 Microservices
	1. Seller.Admin - MVC only for Admin 
	2. Seller.Identity - Api with DB - Entity Asp.Net.USer
	3. Seller.Listings - Api with DB 
		1. Entities - Seller : User, Lising, Deals and Messages from Masstransit
	4. Seller.Messages - Api with DB - Entity  Message
	5. Seller.Offers - Api with DB - Entity Offer
	6. Seller.Listings.Gateway - Api Gateway
	7. Seller.Notifications - Api
	8. Seller.watchdog - Api - AppHealth on http://localhost:5015/healthchecks-ui
	9. Seller.Shared - Library

## App functionality

#### Not Logged User can do
1. See Landing page
2. Login
3. Register

#### Logged User can do
1. **See All Lisings** - *on Get* Direct Call to Listing MS, Search - Client implementation
2. **See Mini Lisings** - *on Get* Direct Call to Listing MS, Search - Client implementation
3. **Add Listing** - *on Post* Direct Call to Listing MS and**Using Messaging** to send message to NotificationsMS Using SingleR
		notify the Client and all Logged User about that new listing is published.
4. **Lising Deatails** - *on Get* See details Milty Call *from Client to LisingMS* and  *from Client OffersMS* to get offersCount
		-  If User **is Owner** of listing
			1.  **See all offers** - *on Get* Call to **Lising.Gateway** ot agregete data from OffersMS And LisingMS
				**Accept**	*on Post* direct call To LisingsMS to crete Deal and set Lising.IsDeal to true and
				**Using Messaging** call to OfferMS to set this IsAccepted to true to all other offer IsDeleted to True
			2.  **Edit Lising** - *on Get* - Direct Call to LisingMS, *on Post* Direct Call edit Lising and,
			**Using Messaging** if Title is changed to *Consumer - OffersMS* (*offer title = listing title* if there are offers change thеir title)
			3.  **Delete Lising** - *on Post* Direct Call edit Lising and, **Using Messaging** to set Offers.IsDeleted all associated with this listing 
			to true - soft delete
		- If User **is not Owner** of listing - **Add Offer** - *on Post* Direct Call to OffersMS
5. **Mine Offers** - *on Get*  Call To **Lisings.Gateway* to aggregate data from  *LisingMS and OffersMS*
		- **Deatails** - see listing details;
		- **Delete** - *on Post* Set IsDeleted to true
6. **Mine Deals** - *on Get*  Call To **Lisings.Gateway** to aggregate data from  *LisingMS Buy Deals And Sale Deals Service*
		and see all Bought Properties and all Sold Properties
7. **Contact Us** - *on Post* irect call to Seller.Messages send message to site administrator 
8. **Logout** - Clent delete token from Localstorage 
	
#### Admin can do
1. Can login in **AdminMS** *on get* Direct call see all sent messages from users and archive them on *on Post* direct call
