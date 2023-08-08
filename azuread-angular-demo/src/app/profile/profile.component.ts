import { Component, OnInit } from '@angular/core';
import { DomSanitizer, SafeResourceUrl } from '@angular/platform-browser';
import { AzureAdDemoService } from '../azure-ad-demo.service';
import { Profile } from '../profile.model';

@Component({
  selector: 'app-profile',
  templateUrl: './profile.component.html',
  styleUrls: ['./profile.component.scss']
})
export class ProfileComponent implements OnInit {
  profile?:Profile;
  profilePic?:SafeResourceUrl;
  constructor(private azureAdDemoService:AzureAdDemoService,
    private domSanitizer:DomSanitizer) { }

  ngOnInit(): void {
    this.getProfile();
    this.getProfilePic();
  }
  getProfile()
  {
    this.azureAdDemoService.getUserProfile()
    .subscribe(profileInfo=>{
      this.profile=profileInfo;
    })
  }
  getProfilePic()
  {
    this.azureAdDemoService.getProfilePic()
    .subscribe(response=>{
      var urlCreator = window.URL ||window.webkitURL
      this.profilePic = this.domSanitizer.bypassSecurityTrustResourceUrl
      (urlCreator.createObjectURL(response));
    });
  }
}
