import { Component, ViewChild } from '@angular/core';
import { ContactService } from '../service/contact.service';
import { Contact } from '../models/models';
import { NgFor } from '@angular/common';
import { Router } from '@angular/router';
import { MatTableDataSource, MatTableModule } from '@angular/material/table';
import { MatPaginator, MatPaginatorModule } from '@angular/material/paginator';
import { contacts } from '../Data/data';

@Component({
  selector: 'app-contact-list',
  standalone: true,
  imports: [NgFor, MatTableModule, MatPaginatorModule],
  templateUrl: './contact-list.component.html',
  styleUrl: './contact-list.component.css'
})
export class ContactListComponent {
  @ViewChild(MatPaginator, {static: false}) paginator: MatPaginator;
  dataSource: MatTableDataSource<Contact> = new MatTableDataSource<Contact>(contacts);
  displayedColumns = ["id", "firstName", "middleName", "lastName"];

  constructor(private contactService: ContactService, private router: Router) { }
  
  ngOnInit() {
    this.dataSource.data = contacts;
    this.dataSource.paginator = this.paginator;
    // this.contactService.getContacts().subscribe({  // Supposed to fetch data, but CORS
    //   next: (contacts) => {
    //     this.contacts = contacts;
    //   }
    // });
  }

  ngAfterViewInit() {
    this.dataSource.paginator = this.paginator;
  }

  navigateTo(id: number) {
    this.router.navigate(['contact-details', id]);
  }
}
