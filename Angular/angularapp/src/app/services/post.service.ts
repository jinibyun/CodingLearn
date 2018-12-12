import { Injectable } from '@angular/core';

// NOTE: ref: https://stackoverflow.com/questions/47236963/no-provider-for-httpclient
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Post } from '../models/Post';

const httpOptions = {
  headers: new HttpHeaders({ 'Content-Type': 'application/json' })
}

// Annotation
@Injectable()
export class PostService {

  // ref: fake api : make sure https
  postsUrl: string = 'https://jsonplaceholder.typicode.com/posts';

  constructor(private http: HttpClient) { }

  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(this.postsUrl);  // 여기서 get은 HTTP Get request를 말한다
  }

  savePost(post: Post): Observable<Post> {
    return this.http.post<Post>(this.postsUrl, post, httpOptions);  // HTTP Post Request
  }

  updatePost(post: Post): Observable<Post> {
    const url = `${this.postsUrl}/${post.id}`;
    return this.http.put<Post>(url, post, httpOptions);

  }

  getPost(id: Number): Observable<Post> {
    const url = `${this.postsUrl}/${id}`;
    return this.http.get<Post>(url);

  }

  removePost(post: Post | number): Observable<Post> {
    const id = typeof post === 'number' ? post : post.id;
    const url = `${this.postsUrl}/${id}`;

    return this.http.delete<Post>(url, httpOptions);

  }
}
