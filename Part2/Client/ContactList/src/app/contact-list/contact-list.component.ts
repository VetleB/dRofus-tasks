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
  @ViewChild(MatPaginator) private paginator: MatPaginator;
  contacts: Contact[] = [];
  dataSource: MatTableDataSource<any> = new MatTableDataSource<any>([]);
  displayedColumns = ["id", "firstName", "middleName", "lastName"];

  constructor(private contactService: ContactService, private router: Router) { }
  
  ngOnInit() {
    this.contacts = contacts;
    this.dataSource.data = contacts;
    // this.contactService.getContacts().subscribe({ 
    //   next: (contacts) => {
    //     this.contacts = contacts;
    //   }
    // });
  }

  ngAfterViewInit() {
    this.dataSource = new MatTableDataSource(this.contacts);
    this.dataSource.paginator = this.paginator;
  }

  navigateTo(id: number) {
    this.router.navigate(['contact-details', id]);
  }
}
