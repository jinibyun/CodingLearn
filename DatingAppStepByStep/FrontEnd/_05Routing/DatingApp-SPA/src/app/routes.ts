import {Routes} from '@angular/router'; // major reference
import { HomeComponent } from './home/home.component';
import { MemberListComponent } from './member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { ListsComponent } from './lists/lists.component';
import { AuthGuard } from './_guards/auth.guard';

// NOTE: manually it should be registered in app.module

export const appRoutes: Routes = [
	// each routes are object
    {path: '', component: HomeComponent}, // note: if it is 'home', then log in and open different tab, and type url such as localhost:4200/ it will throw an error. Therefore it should be empty
	{
        path: '', // e.g. localhost:4200/members means localhost:4200/ + empty + members. It must be like this. It is called "dummy" route

        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard], // AuthGuard should be created at first.
        // in order to centralized authGuard for all components as below
        children: [
            {path: 'members', component: MemberListComponent},
            {path: 'messages', component: MessagesComponent},
            {path: 'lists', component: ListsComponent},
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'}, // ** means "else". NOTE: define it very last. Ordering is important

];
