# Face Detection and Recognition (Emgu CV)

This project implements real-time face detection and face recognition using a webcam.
It is written in **C#** and based on **Emgu CV**, a .NET wrapper for OpenCV.

The system allows adding new faces, training a recognition model, recognizing faces in real time, and managing stored face data.

---

## Features

- Real-time video capture from webcam
- Face detection using Haar Cascade classifier
- Face recognition using **LBPH (Local Binary Patterns Histogram)**
- Add new faces via camera
- Automatic model retraining after changes
- Face deletion support
- Event-based notification when a face is recognized
- Simple integration with Windows Forms (`PictureBox`)

---

## Technologies Used

- C#
- .NET (Windows Forms)
- Emgu CV (OpenCV wrapper for .NET)
- Haar Cascade (`haarcascade_frontalface_alt.xml`)
- LBPHFaceRecognizer

---

## How It Works

1. The webcam is opened and frames are captured in real time.
2. Each frame is converted to grayscale.
3. Faces are detected using a Haar Cascade classifier.
4. If the recognition model is trained:
   - Detected faces are resized to a fixed size.
   - The LBPH recognizer predicts the identity.
   - If confidence is high enough, the face is recognized.
5. Detected faces are highlighted with colored rectangles:
   - **Green** – recognized face
   - **Red** – unknown face
   - **Blue** – detection only (model not trained)

---

## Adding a New Face

1. Enter the person’s name.
2. Make sure exactly one face is visible in the camera.
3. Capture and save the face image.
4. Images are stored in:

--

## Important Notes

- Good lighting conditions improve recognition accuracy.
- Only one face should be visible when adding a new person.
- Recognition threshold is configurable via `result.Distance`.
