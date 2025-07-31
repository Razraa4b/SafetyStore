import * as THREE from 'three';
import { GLTFLoader } from 'three/addons/loaders/GLTFLoader.js';
import { OrbitControls } from 'three/addons/controls/OrbitControls.js';

const scene = new THREE.Scene();
scene.background = null;

const renderer = new THREE.WebGLRenderer({
    antialias: true,
    alpha: true // Enable alpha channel support
});
renderer.setClearColor(0x000000, 0);

let screen = document.getElementById("turtle-container") as HTMLDivElement;
screen.appendChild(renderer.domElement);

// Set camera position and aspect and renderer area size
const camera = new THREE.PerspectiveCamera(75, screen.clientWidth / screen.clientHeight, 0.1, 1000);
renderer.setSize(screen.clientWidth, screen.clientHeight);
camera.position.z = 1;

// Load 3D model
const loader = new GLTFLoader();

loader.load('/models/turtle.glb', gltf => {
    scene.add(gltf.scene);
}, undefined, error => {
    console.error(error);
});

const controls = new OrbitControls(camera, renderer.domElement);
// Controls settings
controls.enableZoom = false;
controls.enablePan = false;
controls.enableDamping = false;
controls.enableRotate = false;

controls.update();

// Update animation on each frame
function animate() {
    requestAnimationFrame(animate);


    controls.update();
    renderer.render(scene, camera);
}

// Subscribe to resize window event
window.addEventListener("resize", () => {
    renderer.setSize(screen.clientWidth, screen.clientHeight);
    camera.aspect = screen.clientWidth / screen.clientHeight;
    camera.updateProjectionMatrix();
});

// Run animation
animate();
