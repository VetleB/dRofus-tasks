import { Component } from '@angular/core';
import { Contact } from '../models/models';
import { ContactService } from '../service/contact.service';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { contacts } from '../Data/data';

@Component({
  selector: 'app-contact-detail',
  standalone: true,
  imports: [],
  templateUrl: './contact-detail.component.html',
  styleUrl: './contact-detail.component.css'
})
export class ContactDetailComponent {
  contact: Contact | undefined;
  id: number;

  constructor(private contactService: ContactService, public route: ActivatedRoute, private router: Router) { }
  
  ngOnInit() {
    this.id = parseInt(this.route.snapshot.params['id']);
    this.contact = contacts.find(c => c.id == this.id);
    // this.contactService.getContacts().subscribe({ 
    //   next: (contact) => {
    //     this.contact = contact;
    //   }
    // });
  }

  public goToList() {
    this.router.navigate(['contact-list']);
  }
}
