import { Component, OnInit, EventEmitter, Output, Input } from '@angular/core';
import { PostService } from '../../services/post.service';
import { Post } from '../../models/Post';

@Component({
  selector: 'app-ninthExample',
  templateUrl: './ninthExample.component.html',
  styleUrls: ['./ninthExample.component.css']
})
export class NinthExampleComponent implements OnInit {

  // @Output and @Input are for "exposing property" to other component
  // post: Post;
  @Output() newPost: EventEmitter<Post> = new EventEmitter();
  @Output() updatePost: EventEmitter<Post> = new EventEmitter();
  @Input() currentPost: Post;
  @Input() isEdit: Boolean;

  // Angular dependency Injection
  constructor(private postService: PostService) { }

  ngOnInit() {
  }

  addPost(title, body) {

    // console.log(title, body);
    if(!title || !body) {
      alert('Please add post');
    } else {
      this.postService.savePost({title, body} as Post).subscribe(post => {
        // console.log(post);
        // emit event to commnunicate different components
        // It is like raise event after saving
        this.newPost.emit(post);
      });
    }
  }

  editPost(){
    // console.log(123);
    this.postService.updatePost(this.currentPost).subscribe(
      post =>{
         console.log(post);
         this.isEdit = false;

         // It is like raise event after updating
         this.updatePost.emit(post);
      }
    );
  }
}
