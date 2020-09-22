import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { ProductsComponent } from './products/products.component';
import { ProductAddEditComponent } from './product-add-edit/product-add-edit.component';
import { CategoryComponent } from './category/category.component';
import { CategorysComponent } from './categorys/categorys.component';
import { CategoryAddEditComponent } from './category-add-edit/category-add-edit.component';

const routes: Routes = [
  { path: '', component: ProductsComponent, pathMatch: 'full' },
  { path: 'product/:id', component: ProductComponent },
  { path: 'product/add', component: ProductAddEditComponent },
  { path: 'product/edit/:id', component: ProductAddEditComponent },

  { path: 'category', component: CategorysComponent },
  { path: 'category/:id', component: CategoryComponent },
  { path: 'category/add', component: CategoryAddEditComponent },
  { path: 'category/edit/:id', component: CategoryAddEditComponent },

  { path: '**', redirectTo: '/' }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
