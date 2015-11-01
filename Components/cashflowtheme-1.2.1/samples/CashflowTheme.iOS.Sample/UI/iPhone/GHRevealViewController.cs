using System;
using System.Drawing;
#if __UNIFIED__
using Foundation;
using UIKit;
#else
using MonoTouch.Foundation;
using MonoTouch.UIKit;
#endif

namespace ThemeSample.UI {
	public class GHRevealViewController : UIViewController {
		protected const float kGHRevealSidebarDefaultAnimationDuration = 0.25f;
		const float kGHRevealSidebarWidth = 260.0f;
		const float kGHRevealSidebarFlickVelocity = 1000.0f;
		UIView _sidebarView;
		UIView _contentView;
		UITapGestureRecognizer _tapRecog;
		UIViewController _sidebarViewController;
		UIViewController _contentViewController;
		UIView searchView;

		public GHRevealViewController (NSCoder aDecoder) : base (aDecoder)
		{
		}

		public GHRevealViewController (IntPtr handle) : base (handle)
		{
		}

		void SetSidebarViewController (UIViewController svc)
		{
			if (_sidebarViewController == null) {
				svc.View.Frame = _sidebarView.Bounds;
				_sidebarViewController = svc;
				AddChildViewController (_sidebarViewController);
				_sidebarView.AddSubview (_sidebarViewController.View);
				_sidebarViewController.DidMoveToParentViewController (this);
			} else if (_sidebarViewController != svc) {
				svc.View.Frame = _sidebarView.Bounds;
				_sidebarViewController.WillMoveToParentViewController (null);
				AddChildViewController (svc);
				View.UserInteractionEnabled = false;
				Transition (_sidebarViewController, svc, 0, UIViewAnimationOptions.TransitionNone, () => {}, (finished) => {
					View.UserInteractionEnabled = true;
					_sidebarViewController.RemoveFromParentViewController ();
					svc.DidMoveToParentViewController (this);
					_sidebarViewController = svc;
				});
			}
		}

		void SetContentViewController (UIViewController cvc)
		{
			if (_contentViewController == null) {
				cvc.View.Frame = _contentView.Bounds;
				_contentViewController = cvc;
				AddChildViewController (_contentViewController);
				_contentView.AddSubview (_contentViewController.View);
				_contentViewController.DidMoveToParentViewController (this);
			} else if (_contentViewController != cvc) {
				cvc.View.Frame = _contentView.Bounds;
				_contentViewController.WillMoveToParentViewController (null);
				AddChildViewController (cvc);
				View.UserInteractionEnabled = false;
				Transition (_contentViewController, cvc, 0, UIViewAnimationOptions.TransitionNone, () => {}, (finished) => {
					View.UserInteractionEnabled = true;
					_contentViewController.RemoveFromParentViewController ();
					cvc.DidMoveToParentViewController (this);
					_contentViewController = cvc;
				});
			}
		}

		public override void ViewDidLoad ()
		{
			SidebarShowing = false;
			Searching = false;
			_tapRecog = new UITapGestureRecognizer (() => HideSidebar());
			_tapRecog.CancelsTouchesInView = true;
			
			View.AutoresizingMask = (UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight);
			
			_sidebarView = new UIView (View.Bounds);
			_sidebarView.AutoresizingMask = (UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight);
			_sidebarView.BackgroundColor = UIColor.Clear;
			View.AddSubview (_sidebarView);
			
			_contentView = new UIView (View.Bounds);
			_contentView.AutoresizingMask = (UIViewAutoresizing.FlexibleWidth | UIViewAutoresizing.FlexibleHeight);
			_contentView.BackgroundColor = UIColor.Clear;
			_contentView.Layer.MasksToBounds = false;
			_contentView.Layer.ShadowColor = UIColor.Black.CGColor;
			_contentView.Layer.ShadowOffset = new SizeF (0.0f, 0.0f);
			_contentView.Layer.ShadowOpacity = 1.0f;
			_contentView.Layer.ShadowRadius = 2.5f;
			_contentView.Layer.ShadowPath = UIBezierPath.FromRect (_contentView.Bounds).CGPath;
			View.AddSubview (_contentView);
			
			if (_sidebarViewController != null) {
				UIViewController temp = _sidebarViewController;
				_sidebarViewController = null;
				SidebarViewController = temp;
			}
			
			if (_contentViewController != null) {
				UIViewController temp = _contentViewController;
				_contentViewController = null;
				ContentViewController = temp;
			}
		}

		public void DragContentView (UIPanGestureRecognizer panGesture)
		{
			float translation = (float) panGesture.TranslationInView (View).X;
			if (panGesture.State == UIGestureRecognizerState.Changed) {
				if (SidebarShowing) {
					if (translation > 0.0f) {
						_contentView.Frame = _contentView.Bounds
						#if __UNIFIED__
						#else
						.OffsetNew (kGHRevealSidebarWidth, 0.0f)
						#endif
						;
						SidebarShowing = true;
					} else if (translation < -kGHRevealSidebarWidth) {
						_contentView.Frame = _contentView.Bounds;
						SidebarShowing = false;
					} else {
						_contentView.Frame = _contentView.Bounds
						#if __UNIFIED__
						#else
						.OffsetNew ((kGHRevealSidebarWidth + translation), 0.0f)
						#endif
						;
					}
				} else {
					if (translation < 0.0f) {
						_contentView.Frame = _contentView.Bounds;
						#if __UNIFIED__
						#else
						SidebarShowing = false
						#endif
						;
					} else if (translation > kGHRevealSidebarWidth) {
						_contentView.Frame = _contentView.Bounds
						#if __UNIFIED__
						#else
						.OffsetNew (kGHRevealSidebarWidth, 0.0f)
						#endif
						;
						SidebarShowing = true;
					} else {
						_contentView.Frame = _contentView.Bounds
						#if __UNIFIED__
						#else
						.OffsetNew (translation, 0.0f)
						#endif
						;
					}
				}
			} else if (panGesture.State == UIGestureRecognizerState.Ended) {
				float velocity = (float) panGesture.VelocityInView (View).X;
				bool show = (Math.Abs (velocity) > kGHRevealSidebarFlickVelocity)
					? (velocity > 0) : (translation > (kGHRevealSidebarWidth / 2));
				ToggleSidebar (show, kGHRevealSidebarDefaultAnimationDuration);
			}
		}

		public void ToggleSidebar (bool show, float duration = kGHRevealSidebarDefaultAnimationDuration)
		{
			ToggleSidebar (show, duration, () => {});
		}

		#if __UNIFIED__
		public void ToggleSidebar (bool show, float duration, Action completion)
		#else
		public void ToggleSidebar (bool show, float duration, NSAction completion)
		#endif
		{
			#if __UNIFIED__
			Action animations = 
			#else
			NSAction animations = 
			#endif
			() 
			=> 
			{
				if (show) {
					_contentView.Frame = _contentView.Bounds
					#if __UNIFIED__
					#else
					.OffsetNew (kGHRevealSidebarWidth, 0.0f)
					#endif
					;
					_contentView.AddGestureRecognizer (_tapRecog);
				} else {
					if (Searching) {
						_sidebarView.Frame = new RectangleF (0.0f, 0.0f, kGHRevealSidebarWidth, (float)View.Bounds.Height);
					} else {
						_contentView.RemoveGestureRecognizer (_tapRecog);
					}
					_contentView.Frame = _contentView.Bounds;
				}
				SidebarShowing = show;
			};
			if (duration > 0.0f) {
				UIView.Animate (duration, 0.0, UIViewAnimationOptions.CurveEaseInOut, animations, completion);
			} else {
				animations ();
				completion ();
			}
		}

		public void ToggleSearch (bool showSearch, UIView srchView, float duration)
		{
			ToggleSearch (showSearch, srchView, duration, () => {});
		}

		public void ToggleSearch (bool showSearch, UIView srchView, float duration, /*NS*/Action completion)
		{
			if (showSearch) {
				srchView.Frame = View.Bounds;
			} else {
				_sidebarView.Alpha = 0.0f;
				_contentView.Frame = View.Bounds
				#if __UNIFIED__
				#else
				.OffsetNew (View.Bounds.Width, 0.0f)
				#endif
				;
				View.AddSubview (_contentView);
			}
			#if __UNIFIED__
			Action animations = 
			#else
			NSAction animations = 
			#endif
			() => 
			{
				if (showSearch) {
					_contentView.Frame = _contentView.Bounds
					#if __UNIFIED__
					#else
					.OffsetNew (View.Bounds.Width, 0.0f)
					#endif
					;
					_contentView.RemoveGestureRecognizer (_tapRecog);
					_sidebarView.RemoveFromSuperview ();
					searchView = srchView;
					View.InsertSubview (searchView, 0);
				} else {
					_sidebarView.Frame = new RectangleF (0.0f, 0.0f, kGHRevealSidebarWidth, (float) View.Bounds.Height);
					_sidebarView.Alpha = 1.0f;
					View.InsertSubview (_sidebarView, 0);
					searchView.Frame = _sidebarView.Frame;
					_contentView.Frame = _contentView.Bounds
					#if __UNIFIED__
					#else
					.OffsetNew (kGHRevealSidebarWidth, 0.0f)
					#endif
					;
				}
			};
			#if __UNIFIED__
			Action fullCompletion 
			#else
			NSAction fullCompletion 
			#endif
			= () => {
				if (showSearch) {
					_contentView.Frame = _contentView.Bounds
					#if __UNIFIED__
					#else
					.OffsetNew (UIScreen.MainScreen.Bounds.Height, 0.0f)
					#endif
					;
					_contentView.RemoveFromSuperview ();
				} else {
					_contentView.AddGestureRecognizer (_tapRecog);
					searchView.RemoveFromSuperview ();
					searchView = null;
				}
				SidebarShowing = true;
				Searching = showSearch;
				completion ();
			};
			if (duration > 0.0) {
				UIView.Animate (duration, 0, UIViewAnimationOptions.CurveEaseInOut, animations, fullCompletion);
			} else {
				animations ();
				fullCompletion ();
			}
		}

		void HideSidebar ()
		{
			ToggleSidebar (false, kGHRevealSidebarDefaultAnimationDuration);
		}

		public bool SidebarShowing { get; private set; }

		public bool Searching { get; private set; }

		public UIViewController SidebarViewController { 
			get { 
				return _sidebarViewController; 
			} 
			set {
				SetSidebarViewController (value);
			} 
		}

		public UIViewController ContentViewController { 
			get { 
				return _contentViewController; 
			} 
			set { 
				SetContentViewController (value);
			} 
		}
	}
}
