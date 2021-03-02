import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { HomeComponent } from './home/home.component';
import { ListsComponent } from './lists/lists.component';
import { MemberDetailComponent } from './members/member-detail/member-detail.component';
import { MemberEditComponent } from './members/member-edit/member-edit.component';
import { MemberListComponent } from './members/member-list/member-list.component';
import { MessagesComponent } from './messages/messages.component';
import { AuthGuard } from './_guards/auth.guard';
import { PreventUnsavedChanges } from './_guards/prevent-unsaved-changes.guard';
import { MemberDetailResolver } from './_resolvers/member-detail.resolver';
import { MemberEditResolver } from './_resolvers/member-edit.resolver';
import { MemberListResolver } from './_resolvers/member-list.resolver';

const routes: Routes = [
  // each routes are object
  {path: '', component: HomeComponent}, // note: if it is 'home', then log in and open different tab, and type url such as localhost:4200/ it will throw an error. Therefore it should be empty
	{
        path: '', // e.g. localhost:4200/members means localhost:4200/ + empty + members. It must be like this. It is called "dummy" route

        runGuardsAndResolvers: 'always',
        canActivate: [AuthGuard], // AuthGuard should be created at first.
        // in order to centralized authGuard for all components as below
        children: [
            {path: 'members', component: MemberListComponent,
            resolve: {users: MemberListResolver}}, /* make data available BEFORE routing start work */
            {path: 'members/:id', component: MemberDetailComponent,
                resolve: {user: MemberDetailResolver}}, // go to member-detail.resolve
            {path: 'member/edit', component: MemberEditComponent,
                resolve: {user: MemberEditResolver}, canDeactivate: [PreventUnsavedChanges]},
            {path: 'messages', component: MessagesComponent},
            {path: 'lists', component: ListsComponent},
        ]
    },
    {path: '**', redirectTo: '', pathMatch: 'full'}, // ** means "else". NOTE: define it very last. Ordering is important

];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
