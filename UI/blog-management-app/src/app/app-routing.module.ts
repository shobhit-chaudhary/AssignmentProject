import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

import { BlogListComponent } from './components/blog-list/blog-list.component';
import { BlogDetailComponent } from './components/blog-detail/blog-detail.component';
import { BlogFormComponent } from './components/blog-form/blog-form.component';

const routes: Routes = [
  { path: '', component: BlogListComponent },
  { path: 'blog/:id', component: BlogDetailComponent },
  { path: 'create', component: BlogFormComponent },
  { path: 'edit/:id', component: BlogFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }