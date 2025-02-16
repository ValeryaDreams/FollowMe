import { Component, HostListener } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  standalone: false,
  styleUrl: './app.component.css'
})
export class AppComponent {
	title = 'FollowMeUI';

    @HostListener('mousemove', ['$event'])
    onMouseMove(event: MouseEvent) {
        const pawCursor = document.getElementById('cat-paw');
        if (pawCursor) {
            pawCursor.style.left = `${event.clientX}px`;
            pawCursor.style.top = `${event.clientY}px`;
        }
    }
}


