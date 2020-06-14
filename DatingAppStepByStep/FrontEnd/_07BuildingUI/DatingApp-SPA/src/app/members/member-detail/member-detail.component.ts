import { Component, OnInit } from '@angular/core';
import { User } from '../../_models/user';
import { UserService } from '../../_services/user.service';
import { AlertifyService } from '../../_services/alertify.service';
import { ActivatedRoute } from '@angular/router';
import { NgxGalleryOptions, NgxGalleryImage, NgxGalleryAnimation } from 'ngx-gallery';

// NOTE: if you are using angular v9, try to use -->> npm install@kolvov/ngx-gallery

@Component({
  selector: 'app-member-detail',
  templateUrl: './member-detail.component.html',
  styleUrls: ['./member-detail.component.css']
})
export class MemberDetailComponent implements OnInit {
  user: User;

  // ref: npmjs.com/package/ngx-gallery
  
  galleryOptions: NgxGalleryOptions[];
  galleryImages: NgxGalleryImage[];

  constructor(private userService: UserService, private alertify: AlertifyService,
    private route: ActivatedRoute) { }

  ngOnInit() {

    //this.loadUser();
    // instead...

    // use resolve in route and use it as below
    this.route.data.subscribe(data => {
      this.user = data['user'];
    });

    this.galleryOptions = [
      {
        width: '500px',
        height: '500px',
        imagePercent: 100,
        thumbnailsColumns: 4,
        imageAnimation: NgxGalleryAnimation.Slide,
        preview: false
      }
    ];
    this.galleryImages = this.getImages();
  }

  // NOTE: if we use this way, BEFORE getUser merthod get called, this page is loaded, which raise an issue : this.user object gets null. Therefore we will have to use above way: "RoutingResolve"

  // loadUser(){
  //   this.userService.getUser(this.route.snapshot.params['id']).subscribe(
  //     (user:User) =>{
  //       this.user = user;
  //     }, error =>{
  //       this.alertify.error(error);
  //     }
  //   );
  // }

  getImages() {
    const imageUrls = [];
    for (let i = 0; i < this.user.photos.length; i++) {
      imageUrls.push({
        small: this.user.photos[i].url,
        medium: this.user.photos[i].url,
        big: this.user.photos[i].url,
        description: this.user.photos[i].description
      });
    }
    return imageUrls;
  }

}
