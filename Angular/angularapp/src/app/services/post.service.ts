import { Injectable } from '@angular/core';

// NOTE: ref: https://stackoverflow.com/questions/47236963/no-provider-for-httpclient
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Post } from '../models/Post';

const httpOptions = {
  headers: new HttpHeaders({'Content-Type': 'application/json'})
}

// Please make sure in "service", they have different decorator(attribute), which is "Injectable".
// Also keep in mind that this "service" must be registered in app.moulde.ts (providers section)
@Injectable()
export class PostService {

  // ref: fake api : make sure https
  postsUrl: string = 'https://jsonplaceholder.typicode.com/posts';

  // Angular Dependency Injection
  constructor(private http: HttpClient) { }

  getPosts() : Observable<Post[]> {
    return this.http.get<Post[]>(this.postsUrl);
  }

  savePost(post: Post): Observable<Post> {
    return this.http.post<Post>(this.postsUrl, post, httpOptions);
  }

  updatePost(post: Post):Observable<Post>{
    const url = `${this.postsUrl}/${post.id}`;
    return this.http.put<Post>(url, post, httpOptions);

  }

  getPost(id:Number):Observable<Post>{
    const url = `${this.postsUrl}/${id}`;
    return this.http.get<Post>(url);

  }

  removePost(post: Post | number): Observable<Post>{
    const id = typeof post === 'number'? post : post.id;
    const url = `${this.postsUrl}/${id}`;

    return this.http.delete<Post>(url, httpOptions);

  }
}
