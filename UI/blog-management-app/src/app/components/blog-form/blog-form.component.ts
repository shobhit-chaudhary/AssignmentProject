import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { BlogService } from '../../services/blog.service';
import { BlogPost } from '../../models/blog-post.model';

@Component({
  selector: 'app-blog-form',
  templateUrl: './blog-form.component.html',
  styleUrls: ['./blog-form.component.css']
})
export class BlogFormComponent implements OnInit {

  blogForm: FormGroup;
  isEditMode = false;

  constructor(
    private fb: FormBuilder,
    private blogService: BlogService,
    private router: Router,
    private route: ActivatedRoute
  ) {
    this.blogForm = this.fb.group({
      username: ['', Validators.required],
      dateCreated: ['', Validators.required],
      text: ['', Validators.required]
    });
  }

  ngOnInit(): void {
    const id = this.route.snapshot.paramMap.get('id');
    if (id) {
      this.isEditMode = true;
      this.blogService.getPost(+id).subscribe(post => {
        this.blogForm.patchValue(post);
      });
    }
  }

  onSubmit(): void {
    if (this.blogForm.valid) {
      const blogPost: BlogPost = this.blogForm.value;
      if (this.isEditMode) {
        const id = +this.route.snapshot.paramMap.get('id')!;
        this.blogService.updatePost(id, blogPost).subscribe(() => {
          this.router.navigate(['/']);
        });
      } else {
        this.blogService.createPost(blogPost).subscribe(() => {
          this.router.navigate(['/']);
        });
      }
    }
  }
}
