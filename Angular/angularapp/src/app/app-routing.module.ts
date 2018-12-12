import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './testComponents/home/home.component';

// post and list components belows
import { SeventhExampleComponent } from './testComponents/seventhExample/seventhExample.component';
import { EigthExampleComponent } from './testComponents/eigthExample/eigthExample.component';
import { PostDetailComponent } from './testComponents/post-detail/post-detail.component';

import { NotFoundComponent } from './testComponents/not-found/not-found.component';


// path에 따라서 해당하는 component를 보여준다. '**'는 해당되는 path 외의 모든 path에 대해 다룬다.
const routes: Routes = [
  { path: '', component: HomeComponent },
  { path: 'users', component: SeventhExampleComponent },
  { path: 'posts', component: EigthExampleComponent },
  { path: 'post/:id', component: PostDetailComponent }, // :id에서 :는 url에서 query param에서 keyName이 id인 param의 값을 받아오는 것이다.
                                                        // e.g.) http://localhost:4200/posts/11
  { path: '**', component: NotFoundComponent }
];

@NgModule({
  exports: [RouterModule],
  imports: [
    RouterModule.forRoot(routes)
  ]
})
export class AppRoutingModule { }
